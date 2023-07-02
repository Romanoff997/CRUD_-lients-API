using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Сlients_API.Services
{
    public class ErrorLogger
    {
        public event EventHandler<ErrorEventArgs> ErrorOccurred;

        public void LogError(string errorMessage)
        {
            // Логика обработки ошибки

            // Создаем объект ErrorEventArgs с информацией об ошибке
            var errorArgs = new ErrorEventArgs(errorMessage);

            // Вызываем событие ErrorOccurred и передаем информацию об ошибке
            OnErrorOccurred(errorArgs);
        }

        protected virtual void OnErrorOccurred(ErrorEventArgs e)
        {
            // Проверяем, есть ли подписчики на событие ErrorOccurred
            if (ErrorOccurred != null)
            {
                // Вызываем событие и передаем информацию об ошибке
                ErrorOccurred(this, e);
            }
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; }

        public ErrorEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
