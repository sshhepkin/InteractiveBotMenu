namespace InteractiveBotMenu;

internal class Program
{
    static void Main()
    {
        string? userName = null;
        bool isRunningApplication = true;

        Console.WriteLine("Добро пожаловать в SunatCarBot!");
        Console.WriteLine("Доступные команды: /start, /help, /info, /exit");

        while (isRunningApplication)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            var command = parts[0].ToLower();
            var argument = parts.Length > 1 ? parts[1] : null;

            switch (command)
            {
                case "/start":
                    Console.Write("Введите ваше имя: ");
                    userName = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(userName))
                    {
                        Console.WriteLine($"Рад знакомству, {userName}! Теперь вам доступна команда /echo.");
                    }
                    else
                    {
                        Console.WriteLine("Имя не может быть пустым.");
                    }

                    break;

                case "/help":
                    Console.WriteLine("Справка:");
                    Console.WriteLine("/start - ввести имя пользователя");
                    Console.WriteLine("/help - показать это сообщение");
                    Console.WriteLine("/info - информация о программе");
                    Console.WriteLine("/echo <текст> - повторить введённый текст (доступно после /start)");
                    Console.WriteLine("/exit - выход из программы");
                    break;

                case "/info":
                    Console.WriteLine("Версия: 1.0.0");
                    Console.WriteLine("Дата создания: 15.08.2025");
                    break;

                case "/echo":
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        Console.WriteLine("Сначала введите имя с помощью команды /start.");
                    }
                    else if (string.IsNullOrWhiteSpace(argument))
                    {
                        Console.WriteLine($"{userName}, укажите текст для повтора: /echo <текст>");
                    }
                    else
                    {
                        Console.WriteLine($"{userName}, вы сказали: {argument}");
                    }

                    break;

                case "/exit":
                    Console.WriteLine("Выход из программы...");
                    isRunningApplication = false;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда. Введите /help для списка доступных команд.");
                    break;
            }
        }
    }
}