import sqlite3

# Добавления нового вида спорта в базу данных.
def add_sport(name, fields):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()
    cur.execute(f'INSERT INTO sports(sport_name, fields) VALUES("{name}", "{fields}")')
    con.commit()
    con.close()

# Получение полей для вида спорта.
def get_fields(sport):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()

    cur.execute(f'SELECT fields FROM sports WHERE sport_name = "{sport}"')
    fields = cur.fetchall()
    print(fields)
    con.close()

    return fields[0]

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