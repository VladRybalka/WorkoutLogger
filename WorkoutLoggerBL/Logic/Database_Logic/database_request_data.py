import sqlite3

def get_all_sports_data():
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        cursor = connection.cursor()
        cursor.execute("SELECT * FROM Sports")
        sports = cursor.fetchall()

    return sports

def get_sport_characteristics(sport):
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        cursor = connection.cursor()
        cursor.execute("SELECT Characteristics FROM Sports WHERE Name = ?", [sport])
        characteristics = cursor.fetchall()    # out: [(element,)]

    return characteristics[0][0]