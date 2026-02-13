import sqlite3

# Добавления нового вида спорта в базу данных.
def add_sport(name, fields):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()

    sql_request = f"CREATE TABLE IF NOT EXISTS sports(id INTEGER PRIMARY KEY AUTOINCREMENT, sport_name, fields)"
    cur.execute(sql_request)
    con.commit()

    # Отправляет запрос на добавление и применяет его.
    cur.execute(f'INSERT INTO sports(sport_name, fields) VALUES("{name}", "{fields}")')
    con.commit()
    con.close()

# Получение полей вида спорта.
def get_fields(sport):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()

    # Отправляет запрос и получает ответ в виде [(элемент)].
    cur.execute(f'SELECT fields FROM sports WHERE sport_name = "{sport}"')
    fields = cur.fetchall()
    con.close()

    return fields[0]

# Создание базы данных по году(если её нет) и создание таблицы по спорту с нужными полями.
def create_empty_year_db(year, sport):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    # Формирует SQL-запрос.
    sql_request = f"CREATE TABLE IF NOT EXISTS {sport}(id INTEGER PRIMARY KEY AUTOINCREMENT, "
    for i in get_fields(sport):
        sql_request += f"{i},"
    sql_request = sql_request[:-1] + ")"

    # Отправляет запрос на создание таблицы и применяет его.
    cur.execute(sql_request)
    con.commit()
    con.close()

# Добавление тренировки.
def add_train(year, sport, data):
    create_empty_year_db(year, sport)

    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    # Формирует запрос на добавление тренировки.
    request = f"INSERT INTO {sport}({get_fields(sport)[0]}) VALUES("
    for i in data:
        request += f"{i},"
    request = request[:-1] + ")"

    # Отправляет запрос и применяет его.
    cur.execute(request)
    con.commit()
    con.close()