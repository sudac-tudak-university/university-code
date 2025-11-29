from complex_number import ComplexNumber

__all__ = ['Calculator']


class Calculator:
    @staticmethod
    def add(a: ComplexNumber, b: ComplexNumber):
        return a.add(b)

    @staticmethod
    def subtract(a: ComplexNumber, b: ComplexNumber):
        return a.subtract(b)

    @staticmethod
    def multiply(a: ComplexNumber, b: ComplexNumber):
        return a.multiply(b)

    @staticmethod
    def divide(a: ComplexNumber, b: ComplexNumber):
        return a.divide(b)
