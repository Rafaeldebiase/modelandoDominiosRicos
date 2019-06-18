using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Command;
using PaymentContext.Shared.Handles;

namespace PaymentContext.Domain.Handler
{
    public class SubscriptionHandler :
    Notifiable,
    IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
     
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
            
                return new CommandResult(false, "Não foi possível realizar o cadastro");
            }

            //verificar de o Documento já está cadastrado
            if (_repository.DocumentExists(command.Document)){
                AddNotification("Document", "Esta CPF já está em uso");
            }
            //varificar se o email está cadastrado
            if (_repository.EmailExists(command.email)){
                AddNotification("Document", "Esta email já está em uso");
            }
            //Gerar VO
            
            var name = new Name (command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.cpf);
            var email = new Email(command.email);
            var address = new Address(
                command.Street, 
                command.Number, 
                command.Neighborhood, 
                command.City, 
                command.State, 
                command.Contry, 
                command.ZipCode);
            

            //Gerar entidades
            var student = new Students(name, document, email, address);            
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Payer,
                address, 
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            
            // salvar informações
            _repository.CreateSubscription(student);
            
            // enviar email de boas vindas 
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Seja bem vindo", "Sua assinatura foi criada" );

            // retornar informações 

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}