// 1. Сумма чисел в диапазоне — for
const rangeStart = Number(prompt('Введите начало диапазона:'));
const rangeEnd = Number(prompt('Введите конец диапазона:'));
const from = Math.min(rangeStart, rangeEnd);
const to = Math.max(rangeStart, rangeEnd);
let rangeSum = 0;

for (let i = from; i <= to; i++) {
  rangeSum += i;
}

alert(`Сумма чисел от ${from} до ${to}: ${rangeSum}`);

// 2. НОД двух чисел — while (алгоритм Евклида)
let numA = Number(prompt('Введите первое число:'));
let numB = Number(prompt('Введите второе число:'));

while (numB !== 0) {
  const remainder = numA % numB;
  numA = numB;
  numB = remainder;
}

alert(`Наибольший общий делитель: ${numA}`);

// 3. Все делители числа — for
const numberForDivisors = Number(prompt('Введите число:'));
let divisors = '';

for (let i = 1; i <= numberForDivisors; i++) {
  if (numberForDivisors % i === 0) {
    divisors += `${i} `;
  }
}

alert(`Делители: ${divisors.trim()}`);

// 4. Количество цифр — while
let numberForDigits = Math.abs(Number(prompt('Введите число:')));
let digitCount = numberForDigits === 0 ? 1 : 0;

while (numberForDigits > 0) {
  digitCount++;
  numberForDigits = Math.floor(numberForDigits / 10);
}

alert(`Количество цифр: ${digitCount}`);

// 5. Статистика по 10 числам — for (одна переменная для ввода)
let positiveCount = 0;
let negativeCount = 0;
let zeroCount = 0;
let evenCount = 0;
let oddCount = 0;
let inputNumber;

for (let i = 1; i <= 10; i++) {
  inputNumber = Number(prompt(`Введите число ${i} из 10:`));

  if (inputNumber > 0) {
    positiveCount++;
  } else if (inputNumber < 0) {
    negativeCount++;
  } else {
    zeroCount++;
  }

  if (inputNumber % 2 === 0) {
    evenCount++;
  } else {
    oddCount++;
  }
}

alert(
  `Положительных: ${positiveCount}\n` +
  `Отрицательных: ${negativeCount}\n` +
  `Нулей: ${zeroCount}\n` +
  `Чётных: ${evenCount}\n` +
  `Нечётных: ${oddCount}`
);

// 6. Калькулятор в цикле — do...while
let continueCalculation;

do {
  const calcA = Number(prompt('Введите первое число:'));
  const operator = prompt('Введите знак (+, -, *, /):');
  const calcB = Number(prompt('Введите второе число:'));
  let calcResult;

  switch (operator) {
    case '+':
      calcResult = calcA + calcB;
      break;
    case '-':
      calcResult = calcA - calcB;
      break;
    case '*':
      calcResult = calcA * calcB;
      break;
    case '/':
      calcResult = calcB !== 0 ? calcA / calcB : 'деление на ноль';
      break;
    default:
      calcResult = 'неверный знак';
  }

  alert(`Результат: ${calcResult}`);
  continueCalculation = confirm('Хотите решить ещё один пример?');
} while (continueCalculation);

// 7. Сдвиг цифр числа — while (подсчёт цифр) + for не нужен
const numberToShift = Number(prompt('Введите число:'));
let shiftCount = Number(prompt('На сколько цифр сдвинуть:'));

let tempNumber = Math.abs(numberToShift);
let digitsLength = 0;

while (tempNumber > 0) {
  digitsLength++;
  tempNumber = Math.floor(tempNumber / 10);
}

shiftCount = shiftCount % digitsLength;
const leftPartDivisor = 10 ** (digitsLength - shiftCount);
const shiftedNumber =
  (numberToShift % leftPartDivisor) * (10 ** shiftCount) +
  Math.floor(numberToShift / leftPartDivisor);

alert(`Результат сдвига: ${shiftedNumber}`);

// 8. Дни недели — do...while (пока пользователь нажимает OK)
const weekDays = [
  'Понедельник',
  'Вторник',
  'Среда',
  'Четверг',
  'Пятница',
  'Суббота',
  'Воскресенье',
];
let dayIndex = 0;
let showNextDay;

do {
  alert(`День недели: ${weekDays[dayIndex]}`);
  dayIndex = (dayIndex + 1) % weekDays.length;
  showNextDay = confirm('Хотите увидеть следующий день?');
} while (showNextDay);

// 9. Таблица умножения — вложенные for
let multiplicationTable = '';

for (let multiplier = 2; multiplier <= 9; multiplier++) {
  for (let multiplicand = 1; multiplicand <= 10; multiplicand++) {
    multiplicationTable += `${multiplier} × ${multiplicand} = ${multiplier * multiplicand}\n`;
  }
  multiplicationTable += '\n';
}

alert(multiplicationTable);

// 10. «Угадай число» — while (бинарный поиск)
let minRange = 0;
let maxRange = 100;
let middle;
let userAnswer;

while (true) {
  middle = Math.floor((minRange + maxRange) / 2);
  userAnswer = prompt(`Ваше число > ${middle}, < ${middle} или == ${middle}?\n(введите >, < или ==)`);

  if (userAnswer === '==' || userAnswer === '=') {
    alert(`Число угадано: ${middle}`);
    break;
  }

  if (userAnswer === '>') {
    minRange = middle + 1;
  } else if (userAnswer === '<') {
    maxRange = middle - 1;
  }
}
