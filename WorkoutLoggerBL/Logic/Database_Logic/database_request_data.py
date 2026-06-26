import sqlite3

def get_all_sports():
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        cursor = connection.cursor()
        cursor.execute("SELECT * FROM Sports")
        sports = cursor.fetchall()

    return sports

