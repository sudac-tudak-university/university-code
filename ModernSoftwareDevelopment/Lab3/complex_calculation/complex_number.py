__all__ = ['ComplexNumber']


class ComplexNumber:
    _real: float
    _image: float

    def __init__(self, real: float, image: float):
        self._real = real
        self._image = image

    def add(self, other: 'ComplexNumber') -> 'ComplexNumber':
        result_real = self._real + other._real
        result_image = self._image + other._image
        return ComplexNumber(result_real, result_image)

    def subtract(self, other: 'ComplexNumber') -> 'ComplexNumber':
        result_real = self._real - other._real
        result_image = self._image - other._image
        return ComplexNumber(result_real, result_image)

    def multiply(self, other: 'ComplexNumber') -> 'ComplexNumber':
        # (a+bi)*(c+di) = (ac-bd) + (ad+bc)i
        a, b = self._real, self._image
        c, d = other._real, other._image
        result_real = a * c - b * d
        result_image = a * d + b * c
        return ComplexNumber(result_real, result_image)

    def divide(self, other: 'ComplexNumber') -> 'ComplexNumber':
        # (a+bi)/(c+di) = (a * c + b * d) / (c^2 + d^2) + (b * c - a * d) / (c^2 + d^2)i.
        a, b = self._real, self._image
        c, d = other._real, other._image

        denominator = pow(c, 2) + pow(d, 2)
        if denominator == 0:
            raise ZeroDivisionError('Division by zero complex number')

        result_real = (a * c + b * d) / denominator
        result_image = (b * c - a * d) / denominator

        return ComplexNumber(result_real, result_image)

    def __str__(self):
        return f'{self._real}+{self._image}i'
