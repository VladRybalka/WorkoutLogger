import sqlite3

# Создание базы данных по году(если её нет) и создание таблицы по спорту с нужными полями.
def create_empty_year_db(year, sport, fields):
    con = sqlite3.connect(f'Data\\{year}.db')
    cur = con.cursor()

    sqlRequest = f"CREATE TABLE IF NOT EXISTS {sport}("
    for i in fields:
        sqlRequest += f"{i},"
    sqlRequest = sqlRequest[:-1] + ")"
    print(sqlRequest)

    cur.execute(sqlRequest)