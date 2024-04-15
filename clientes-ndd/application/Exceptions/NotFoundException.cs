using System;
namespace application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string nome, object key): base($"{nome} ({key}) não foi encontrado")
        {

        }
    }

}
