from calculator import Calculator
from complex_number import ComplexNumber
from interface import UserInterface


AVAILABLE_OPERATIONS = ('+', '-', '*', '/')

def main():
    ui = UserInterface('Калькулятор комплексных чисел')
    app_run = True

    while app_run:
        try:
            first_number_real = ui.get_number_input('Введите действительную часть первого числа: ')
            first_number_image = ui.get_number_input('Введите мнимую часть первого числа: ')
            second_number_real = ui.get_number_input('Введите действительную часть второго числа: ')
            second_number_image = ui.get_number_input('Введите мнимую чатсь второго числа: ')
            operation = ui.get_input(f'Введите желаемую операцию {AVAILABLE_OPERATIONS}: ')

            first_complex_number = ComplexNumber(first_number_real, first_number_image)
            second_complex_number = ComplexNumber(second_number_real, second_number_image)

            res = None

            match operation:
                case '+':
                    res = Calculator.add(first_complex_number, second_complex_number)
                case '-':
                    res = Calculator.subtract(first_complex_number, second_complex_number)
                case '*':
                    res = Calculator.multiply(first_complex_number, second_complex_number)
                case '/':
                    res = Calculator.divide(first_complex_number, second_complex_number)
                case _:
                    raise Exception(f'Введена неверная операция "{operation}". Доступные операции: f{AVAILABLE_OPERATIONS}')

            ui.display_result(res)
        except Exception as e:
            print('Ошибка:', e)


if __name__ == '__main__':
    main()