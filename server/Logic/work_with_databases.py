import sqlite3

def add_sport(name, fields):
    con = sqlite3.connect('Data\\sports_data\\sports.db')
    cur = con.cursor()
    sqlRequest = f'INSERT INTO sports(sport_name, fields) VALUES("{name}", "{fields}")'
    cur.execute(sqlRequest)
    con.commit()
    con.close()

# Создание базы данных по году(если её нет) и создание таблицы по спорту с нужными полями.
def create_empty_year_db(year, sport, fields):
    con = sqlite3.connect(f'Data\\workout_data\\{year}.db')
    cur = con.cursor()

    sqlRequest = f"CREATE TABLE IF NOT EXISTS {sport}(id INTEGER PRIMARY KEY AUTOINCREMENT, "
    for field in fields:
        sqlRequest += f"{field},"
    sqlRequest = sqlRequest[:-1] + ")"

    cur.execute(sqlRequest)
    con.commit()
    con.close()