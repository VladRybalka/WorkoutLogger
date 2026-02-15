import Logic.work_with_databases as database_logic

if __name__ == "__main__":
    while 1:
        menu = int(input("0 - добавить спорт, 1 - добавить тренировку, 2 - посмотреть поля спорта,"
                         " 3 - получить тренировку по дате: "))
        if menu == 0:
            sport = input("Введите название: ")
            fields = input("Введите названия характеристик: ")
            database_logic.add_sport(sport, fields)
        elif menu == 1:
            sport = input("Введите название: ")
            enter = []
            field = database_logic.get_fields(sport).split(",")
            for i in range(len(field)):
                enter.append(input(field[i].strip() + ": "))
            database_logic.add_train(2025, sport, enter)
        elif menu == 2:
            sport = input("Введите название: ")
            print(database_logic.get_fields(sport))