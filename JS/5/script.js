// Рекурсивные функции

//1 Степень

let func1 = (num, pow) => {
  if (pow === 1) {
    return num;
  } else {
    return num * func1(num, pow - 1);
  }
}

console.log("1. Степень числа: 2 в 6 степени = " + func1(2, 6));

//2 Поиск наибольшего общего делителя

let func2 = (num1, num2) => {
  if (num2 === 0) {
    return num1;
  } else {
    return func2(num2, num1 % num2);
  }
}

console.log("2. Наибольший общий делитель: 12 и 15 = " + func2(12, 15));

//3 Максимальная цифра в числе

let func3 = (num) => {
  if (num < 10) {
    return num;
  } else {
    return Math.max(num % 10, func3(Math.floor(num / 10)));
  }
}

console.log("3. Максимальная цифра в числе: 12431563 = " + func3(12431563));

//4 Проверка на простое

let func4 = (num, divisor = 2) => {
  if (num <= 1) return false;
  if (num <= 3) return true;
  
  if (divisor > Math.sqrt(num)) return true;
  if (num % divisor === 0) return false;
  
  return func4(num, divisor + 1);
}

console.log("4. Простое ли число: 80 = " + func4(80));
console.log("   Простое ли число: 17 = " + func4(17));

//5 Множетели числа в возрастающем порядке

let func5 = (num, divisor = 2, res = []) => {
  if (num < 2 && res.length === 0) return []

  if (num === 1) {
    return res;
  }

  if (num % divisor === 0) {
    res.push(divisor);
    return func5(num / divisor, divisor, res);
  } else {
    return func5(num, divisor + 1, res);
  }
}

console.log(`5. Число 100 – множители ${func5(100).join(' * ')}`);

//6 Число Фибоначи по порядковому номеру

function getFibonacci(n) {
  if (n === 1 || n === 2) {
    return 1;
  }

  return getFibonacci(n - 1) + getFibonacci(n - 2);
}

console.log("6. Число Фибоначи по порядковому номеру: 7 = " + getFibonacci(7));