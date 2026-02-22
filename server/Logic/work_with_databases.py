import sqlite3

#region -==- Sport -==-

# Добавления нового вида спорта в базу данных.
def add_sport(name, fields):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()

    sql_request = f"CREATE TABLE IF NOT EXISTS sports(id INTEGER PRIMARY KEY AUTOINCREMENT, sport_name TEXT, fields TEXT)"
    cur.execute(sql_request)
    con.commit()

    # Отправляет запрос на добавление и применяет его.
    cur.execute(f'INSERT INTO sports(sport_name, fields) VALUES("{name}", "{"Day INTEGER, Month INTEGER, " + fields}")')
    con.commit()
    con.close()

# Получение полей вида спорта.
def get_fields(sport):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()

    # Отправляет запрос и получает ответ в виде [(элемент)].
    cur.execute(f'SELECT fields FROM sports WHERE sport_name = "{sport}"')
    answer = cur.fetchall()
    con.close()

    return answer[0][0]

#endregion

#region -==- Trains -==-

# Создание базы данных по году(если её нет) и создание таблицы по спорту с нужными полями.
def create_empty_year_db(year, sport):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    # Формирует SQL-запрос.
    sql_request = (f"CREATE TABLE IF NOT EXISTS {sport}(id INTEGER PRIMARY KEY AUTOINCREMENT, "
                   f"{get_fields(sport)})")

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
    fields_name = ",".join(get_fields(sport).split(" ")[::2])
    sql_request = f"INSERT INTO {sport}({fields_name}) VALUES(" + ",".join(data) + ")"

    # Отправляет запрос и применяет его.
    cur.execute(sql_request)
    con.commit()
    con.close()

def get_train(sport, year, month, day):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    # Отправляет запрос и получает ответ в виде [(элемент)].
    cur.execute(f'SELECT {get_fields(sport)} FROM {sport} WHERE Month = {month} and Day = "{day}"')
    answer = cur.fetchall()
    con.close()

    return answer

#endregion