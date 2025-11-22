// Вариант 7: Гостевая книга

class Programm
{
    static void Main()
    {

        void writeError(string message)
        {
            Console.WriteLine("Ошибка: " + message);
        }

        void notifyAboutEmptyList()
        {
            Console.WriteLine("Записи отсутствуют");
        }

        string safetyReadLine(bool trim = true)
        {
            string? input = Console.ReadLine();

            if (input == null)
            {
                return "";
            }

            if (trim)
            {
                return input.Trim();
            }

            return input;
        }

        List<string> notes = new List<string>();
        char command = '5';

        while (command != '0')
        {
            switch (command)
            {
                case '1':
                    Console.WriteLine("Введите запись (Формат: Сообщение, Время): ");
                    string newNote = safetyReadLine();

                    if (newNote == "")
                    {
                        writeError("Введена пустая запись");
                    }

                    notes.Add(newNote);
                    Console.WriteLine("Запись добавлена.");
                    break;
                case '2':
                    Console.WriteLine("Введите номер записи, которую хотите удалить");
                    string inputNoteNumber = safetyReadLine();
                    bool isIntegerInput = int.TryParse(inputNoteNumber, out int noteNumber);

                    if (!isIntegerInput || noteNumber == 0)
                    {
                        writeError("Введен некорректный номер записи");
                        break;
                    }

                    int noteIndex = noteNumber - 1;

                    if (notes.Count - 1 < noteIndex || noteIndex < 0)
                    {
                        writeError("Записи с номером " + noteNumber + " нет в списке");
                        break;

                    }

                    notes.RemoveAt(noteIndex);
                    Console.WriteLine("Запись с номером " + noteNumber + " удалена");
                    break;

                case '3':
                    if (notes.Count == 0)
                    {
                        notifyAboutEmptyList();
                        break;
                    }

                    Console.WriteLine("Все записи в книге: ");
                    foreach(var note in notes)
                    {
                        int number = notes.IndexOf(note) + 1;
                        Console.WriteLine(number + ") " + note);
                    }
                    break;
                case '4':
                    Console.Write("Введите время прихода (например, 19:00): ");
                    string inputTime = safetyReadLine();
                    bool isInputTimeValid = TimeSpan.TryParse(inputTime, out TimeSpan targetTime);

                    if (string.IsNullOrWhiteSpace(inputTime) || !isInputTimeValid)
                    {
                        writeError("Некорректный формат времени. Ожидается HH:mm (например, 19:00).");
                        break;
                    }

                    List<string> matches = new List<string>();

                    for (int i = 0; i < notes.Count; i++)
                    {
                        string note = notes[i];
                        // Ожидаем формат: "Сообщение, Время" — время после последней запятой
                        string[] parts = note.Split(',');
                        if (parts.Length < 2) continue;

                        string timePart = parts[parts.Length - 1].Trim();

                        if (TimeSpan.TryParse(timePart, out TimeSpan noteTime) && noteTime == targetTime)
                        {
                            matches.Add(note);
                        }
                    }

                    if (matches.Count == 0)
                    {
                        Console.WriteLine("Записей с временем " + inputTime + " не найдено.");
                    }
                    else
                    {
                        Console.WriteLine("Записи с временем " + inputTime + ":");
                        foreach (var match in matches)
                        {
                            int number = matches.IndexOf(match) + 1;
                            Console.WriteLine(number + ") " + match);
                        }
                    }
                    break;

                case '5':
                    Console.WriteLine("Доступные команды: ");
                    Console.WriteLine("1 - Добавить запись");
                    Console.WriteLine("2 - Удалить запись по номеру");
                    Console.WriteLine("3 - Показать все записи");
                    Console.WriteLine("4 - Показать все записи по временному промежутку");
                    Console.WriteLine("5 - Показать доступные команды");
                    Console.WriteLine("0 - Выйти из программы");
                    break;
                default:
                    Console.WriteLine("Введена неизвестная команда: " + command);
                    Console.WriteLine("Чтобы посмотреть список команд, введите \"5\"");
                    break;

            }

            Console.Write("Введите команду: ");
            command = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }
    }
}