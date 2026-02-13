import sqlite3

# Добавления нового вида спорта в базу данных.
def add_sport(name, fields):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()
    cur.execute(f'INSERT INTO sports(sport_name, fields) VALUES("{name}", "{fields}")')
    con.commit()
    con.close()

# Получение полей вида спорта.
def get_fields(sport):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()
    cur.execute(f'SELECT fields FROM sports WHERE sport_name = "{sport}"')
    fields = cur.fetchall()
    con.close()

    return fields[0]

# def get_count_fields(sport):
#     con = sqlite3.connect('Data\\sports_data\\sports.db')
#     cur = con.cursor()
#     cur.execute(f'SELECT fields FROM sports WHERE sport_name = "{sport}"')
#     fields = cur.fetchall()
#     con.close()
#     return len(str(fields).split(",")) - 1

# Создание базы данных по году(если её нет) и создание таблицы по спорту с нужными полями.
def create_empty_year_db(year, sport):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    sql_request = f"CREATE TABLE IF NOT EXISTS {sport}(id INTEGER PRIMARY KEY AUTOINCREMENT, "
    for i in get_fields(sport):
        sql_request += f"{i},"
        print(i)
    sql_request = sql_request[:-1] + ")"
    print(sql_request)
    cur.execute(sql_request)
    con.commit()
    con.close()

# Добавление тренировки.
def add_train(year, sport, data):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    request = f"INSERT INTO {sport}({get_fields(sport)[0]}) VALUES("
    for i in data:
        request += f"{i},"
    request = request[:-1] + ")"

    cur.execute(request)
    con.commit()
    con.close()