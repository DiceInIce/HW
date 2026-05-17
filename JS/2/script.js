// 1. Возрастная категория — if / else if (несколько диапазонов)
const age = Number(prompt('Введите ваш возраст:'));
let ageCategory;

if (age >= 0 && age <= 2) {
  ageCategory = 'ребёнок';
} else if (age >= 12 && age <= 18) {
  ageCategory = 'подросток';
} else if (age > 18 && age < 60) {
  ageCategory = 'взрослый';
} else if (age >= 60) {
  ageCategory = 'пенсионер';
} else {
  ageCategory = 'категория не определена';
}

alert(`Вы — ${ageCategory}.`);

// 2. Спецсимвол на клавише — switch (фиксированные значения 0–9)
const keyNumber = Number(prompt('Введите число от 0 до 9:'));
let specialSymbol;

switch (keyNumber) {
  case 0:
    specialSymbol = ')';
    break;
  case 1:
    specialSymbol = '!';
    break;
  case 2:
    specialSymbol = '@';
    break;
  case 3:
    specialSymbol = '#';
    break;
  case 4:
    specialSymbol = '$';
    break;
  case 5:
    specialSymbol = '%';
    break;
  case 6:
    specialSymbol = '^';
    break;
  case 7:
    specialSymbol = '&';
    break;
  case 8:
    specialSymbol = '*';
    break;
  case 9:
    specialSymbol = '(';
    break;
  default:
    specialSymbol = 'неверное число';
}

alert(`Спецсимвол: ${specialSymbol}`);

// 3. Одинаковые цифры в трёхзначном числе — if
const threeDigit = Number(prompt('Введите трёхзначное число:'));
const digit1 = Math.floor(threeDigit / 100);
const digit2 = Math.floor((threeDigit % 100) / 10);
const digit3 = threeDigit % 10;
const hasDuplicate = digit1 === digit2 || digit1 === digit3 || digit2 === digit3;

alert(hasDuplicate ? 'В числе есть одинаковые цифры' : 'Все цифры разные');

// 4. Високосный год — if (составное условие)
const year = Number(prompt('Введите год:'));
const isLeap = (year % 400 === 0) || (year % 4 === 0 && year % 100 !== 0);

alert(isLeap ? 'Високосный год' : 'Невисокосный год');

// 5. Палиндром (пятизначное число) — if
const fiveDigit = Number(prompt('Введите пятизначное число:'));
const d1 = Math.floor(fiveDigit / 10000);
const d2 = Math.floor((fiveDigit % 10000) / 1000);
const d3 = Math.floor((fiveDigit % 1000) / 100);
const d4 = Math.floor((fiveDigit % 100) / 10);
const d5 = fiveDigit % 10;
const isPalindrome = d1 === d5 && d2 === d4;

alert(isPalindrome ? 'Палиндром' : 'Не палиндром');

// 6. Конвертер валют — switch (выбор валюты)
const USD_TO_EUR = 0.92;
const USD_TO_UAN = 41.5;
const USD_TO_AZN = 1.7;

const usdAmount = Number(prompt('Введите сумму в USD:'));
const currency = prompt('В какую валюту перевести? (EUR / UAN / AZN):').toUpperCase();
let convertedAmount;

switch (currency) {
  case 'EUR':
    convertedAmount = usdAmount * USD_TO_EUR;
    break;
  case 'UAN':
    convertedAmount = usdAmount * USD_TO_UAN;
    break;
  case 'AZN':
    convertedAmount = usdAmount * USD_TO_AZN;
    break;
  default:
    convertedAmount = null;
}

alert(
  convertedAmount !== null
    ? `${usdAmount} USD = ${convertedAmount} ${currency}`
    : 'Неизвестная валюта'
);

// 7. Скидка на покупку — if / else if (ступени суммы)
const purchaseSum = Number(prompt('Введите сумму покупки:'));
let discountPercent;

if (purchaseSum >= 500) {
  discountPercent = 7;
} else if (purchaseSum >= 300) {
  discountPercent = 5;
} else if (purchaseSum >= 200) {
  discountPercent = 3;
} else {
  discountPercent = 0;
}

const totalToPay = purchaseSum - purchaseSum * (discountPercent / 100);
alert(`Скидка: ${discountPercent}%. К оплате: ${totalToPay}`);

// 8. Окружность в квадрате — if (да / нет)
const circumference = Number(prompt('Введите длину окружности:'));
const squarePerimeter = Number(prompt('Введите периметр квадрата:'));
const circleDiameter = circumference / Math.PI;
const squareSide = squarePerimeter / 4;
const fitsInSquare = circleDiameter <= squareSide;

alert(fitsInSquare ? 'Окружность помещается в квадрат' : 'Окружность не помещается в квадрат');

// 9. Викторина — if (проверка каждого ответа)
let score = 0;

const answer1 = Number(prompt('2 + 2 = ?\n1 — 3\n2 — 4\n3 — 5'));
if (answer1 === 2) {
  score += 2;
}

const answer2 = Number(prompt('Столица России?\n1 — Киев\n2 — Москва\n3 — Минск'));
if (answer2 === 2) {
  score += 2;
}

const answer3 = Number(prompt('Сколько дней в неделе?\n1 — 5\n2 — 6\n3 — 7'));
if (answer3 === 3) {
  score += 2;
}

alert(`Вы набрали ${score} баллов из 6`);

// 10. Следующая дата — if (длина месяца, високосный год)
const day = Number(prompt('Введите день:'));
const month = Number(prompt('Введите месяц:'));
const inputYear = Number(prompt('Введите год:'));

const leap = (inputYear % 400 === 0) || (inputYear % 4 === 0 && inputYear % 100 !== 0);
let daysInMonth;

if (month === 2) {
  daysInMonth = leap ? 29 : 28;
} else if (month === 4 || month === 6 || month === 9 || month === 11) {
  daysInMonth = 30;
} else {
  daysInMonth = 31;
}

let nextDay = day + 1;
let nextMonth = month;
let nextYear = inputYear;

if (nextDay > daysInMonth) {
  nextDay = 1;
  nextMonth += 1;
}

if (nextMonth > 12) {
  nextMonth = 1;
  nextYear += 1;
}

alert(`Следующая дата: ${nextDay}.${nextMonth}.${nextYear}`);
