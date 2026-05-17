// 1. Приветствие по имени
const userName = prompt('Как вас зовут?');
alert(`Привет, ${userName}!`);

// 2. Возраст по году рождения
const CURRENT_YEAR = 2026;
const birthYear = Number(prompt('Введите год вашего рождения:'));
const age = CURRENT_YEAR - birthYear;
alert(`Вам ${age} лет.`);

// 3. Периметр квадрата
const squareSide = Number(prompt('Введите длину стороны квадрата:'));
const squarePerimeter = squareSide * 4;
alert(`Периметр квадрата: ${squarePerimeter}`);

// 4. Площадь окружности
const circleRadius = Number(prompt('Введите радиус окружности:'));
const circleArea = Math.PI * circleRadius ** 2;
alert(`Площадь окружности: ${circleArea}`);

// 5. Скорость для поездки
const distanceKm = Number(prompt('Введите расстояние между городами (км):'));
const travelHours = Number(prompt('За сколько часов хотите добраться?'));
const speed = distanceKm / travelHours;
alert(`Необходимая скорость: ${speed} км/ч`);

// 6. Конвертер валют (доллары → евро)
const USD_TO_EUR = 0.92;
const dollars = Number(prompt('Введите сумму в долларах:'));
const euros = dollars * USD_TO_EUR;
alert(`${dollars} $ = ${euros} €`);

// 7. Файлы на флешке
const flashGb = Number(prompt('Введите объём флешки (Гб):'));
const fileSizeMb = 820;
const filesCount = Math.floor((flashGb * 1024) / fileSizeMb);
alert(`На флешку поместится ${filesCount} файлов по ${fileSizeMb} Мб`);

// 8. Шоколадки и сдача
const wallet = Number(prompt('Сколько денег в кошельке?'));
const chocolatePrice = Number(prompt('Цена одной шоколадки?'));
const chocolateCount = Math.floor(wallet / chocolatePrice);
const change = wallet % chocolatePrice;
alert(`Можно купить: ${chocolateCount} шт., сдача: ${change}`);

// 9. Трёхзначное число задом наперёд
const threeDigitNumber = Number(prompt('Введите трёхзначное число:'));
const lastDigit = threeDigitNumber % 10;
const middleDigit = Math.floor((threeDigitNumber % 100) / 10);
const firstDigit = Math.floor(threeDigitNumber / 100);
const reversedNumber = lastDigit * 100 + middleDigit * 10 + firstDigit;
alert(`Число наоборот: ${reversedNumber}`);

// 10. Чётное или нет (без if и switch)
const integer = Number(prompt('Введите целое число:'));
alert((integer % 2 === 0 && 'Чётное число') || 'Нечётное число');
