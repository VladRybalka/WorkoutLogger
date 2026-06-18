import sqlite3

connection = sqlite3.connect('data.db')

def init_database():
    cursor = connection.cursor()

    cursor.execute("")