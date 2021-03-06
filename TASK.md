# Тестовое задание

Необходимый набор инструментов:
* Платформа .NET и язык C#
* Selenium WebDriver
* Браузер Chrome или IE старше 9 версии

Пояснить выбор дополнительных инструментов, если таковые будут использованы.
К заданию приложить файл с инструкцией по сборке и запуску.

## Задание

Пройти по [http://appulatebeta.com/signup-old/intro.aspx](ссылке)
Нажать на ссылку Let’s begin!
Написать автотест для двух этапов регистрации

Тест должен проверить, что:
* При вводе валидных данных не происходит ошибок.
* Добавление и удаление локаций возможно
* Телефон с первого этапа регистрации копируется во второй
* Ввод невалидных данных обрабатывается и вызывает предупреждения для пользователя

Валидные данные:

| Поле                | Условие                                                          |
| --------------------- | -------------------------------------------------------------- |
| Firm / Company Name | Текстовое, обязательное, длина 128 символов                      |
| Street Address 1    | Текстовое, обязательное, длина 128 символов                      |
| City                | Текстовое, обязательное, длина 50 символов                       |
| State               | Обязательное                                                     |
| Zip                 | Текстовое, обязательное, длина 50 символов                       |
| Phone               | Текстовое, обязательное, длина 100 символов                      |
| Phone               | Текстовое, обязательное, длина 100 символов                      |
| First Name          | Текстовое, обязательное, длина 16 символов                       |
| Last Name           | Текстовое, обязательное, длина 16 символов                       |
| Email               | Обязательное. Удовлетворяет условию `(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)`. Длина 64 символа. |
| Email Confirmation  | Обязательное. Значение совпадает с тем, что введено в поле email.|
| New Password        | Обязательное. Удовлетворяет условиям на форме.                   |
| Confirm Password    | Обязательное. Значение совпадает с тем, что введено в поле password. |

## Дополнительно

В случае ошибки во время прохождения теста необходимо сделать скриншот.
Найденные баги описать на английском языке
