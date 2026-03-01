import Logic.work_with_databases as database_logic

if __name__ == "__main__":
    while 1:
        menu = int(input("0 - добавить спорт, 1 - добавить тренировку, 2 - посмотреть поля спорта,"
                         " 3 - получить тренировку по дате: "))
        if menu == 0:
            sport = input("Введите название спорта: ")
            fields = input("Введите названия характеристик: ")
            database_logic.add_sport(sport, fields)
        elif menu == 1:
            sport = input("Введите название спорта: ")
            year = int(input("Введите год: "))
            enter = []
            field = database_logic.get_fields(sport).split(",")
            for i in range(len(field)):
                enter.append(input(field[i].strip() + ": "))
            database_logic.add_train(year, sport, enter)
        elif menu == 2:
            sport = input("Введите название спорта: ")
            print(database_logic.get_fields(sport))
        elif menu == 3:
            sport = input("Введите название спорта: ")
            year = int(input("Введите год: "))
            month = int(input("Введите месяц: "))
            day = int(input("Введите день: "))

            answer = database_logic.get_train(sport, year, month, day)
            fields = database_logic.get_fields(sport).split(" ")[::2]

            for i in range(len(answer)):
                print()
                print(i + 1)
                for j in range(len(fields)):
                    print(f"{fields[j].strip()}: {answer[i][j]}")
        else:
            break

        print()