import Logic.work_with_databases as database_logic

if __name__ == "__main__":
    while 1:
        menu = int(input("0 - добавить спорт, 1 - добавить тренировку: "))
        if menu == 0:
            sport = input("Введите название: ")
            fields = input("Введите названия характеристик: ")
            database_logic.add_sport(sport, fields)
        elif menu == 1:
            sport = input("Введеди название: ")
            enter = []
            field = database_logic.get_fields("Cycling")[0].split(",")
            for i in range(len(field)):
                enter.append(input(field[i].strip() + ": "))
            database_logic.add_train(2025, sport, enter)