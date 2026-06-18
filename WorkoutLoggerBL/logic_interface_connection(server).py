import flask as f

connect = f.Flask(__name__)

@connect.route('/test')
def test():
    print("hello world")
    return "200"

connect.run(port = 5001)