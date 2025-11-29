from typing import Any

__all__ = ['UserInterface']


class UserInterface:
    def __init__(self, greeting_message: str | None = None):
        if greeting_message is None or greeting_message == '':
            return
        print(greeting_message)

    def get_input(self, message: str):
        return input(message).strip()

    def get_number_input(self, message: str):
        try:
            return float(self.get_input(message).strip())
        except Exception:
            raise Exception('Введено не число')

    def display_result(self, result: Any):
        print(result)
