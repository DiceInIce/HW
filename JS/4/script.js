
//1 Сравнение чисел
let func1 = (a, b) => {
  if (a == b) {
    return 0
  } else return a > b ? 1 : -1;
}

console.log("1. Сравнение чисел: 2 и 1 = " + func1(2, 1));

//2 Факториал числа

let func2 = (a) => {
  let result = 1;
  for (let i = 1; i <= a; i++) {
    result *= i;
  }
  return result;
}

console.log("2. Факториал числа: 5 = " + func2(5));

//3 Три цифры в одно

let func3 = (a, b, c) => {
  if (isDigit(a) || isDigit(b) || isDigit(c)) {
    return `${a}${b}${c}`;
  } else {
    return 0;
  }
}

function isDigit(n) {
  return n >= 0 && n <= 9;
}

console.log("3. Три цифры в одно: 1 2 3 = " + func3(1, 2, 3));

//4 Площадь прямоугольника 

let func4 = (...args) => {
  switch (args.length) {
    case 3:
      return 0;
    case 2:
      return args[0] * args[1];
    case 1:
      return args[0] * args[0];
    case 0:
      return 0;
  }
}

console.log("4. Площадь прямоугольника: 2 3 = " + func4(2, 3));
console.log("   Площадь квадрата : 4 = " + func4(4));

//5 Проверка на совершенное число

let func5 = (num) => {
  if (num <= 1) return false;

  let sum = 1;

  for (let i = 2; i <= Math.sqrt(num); i++) {
    if (num % i === 0) {
      sum += i;
      if (i !== num / i) {
        sum += num / i;
      }
    }
  }
  return sum === num;
}

console.log("5. Проверка на совершенное число: 6 = " + func5(6));
console.log("   Проверка на совершенное число: 10 = " + func5(10));

//6 Совершенные числа в диапазоне

let func6 = (a, b) => {
  let result = [];
  for (let i = a; i <= b; i++) {
    if (func5(i)) {
      result.push(i);
    }
  }
  return result;
}

console.log("6. Совершенные числа в диапазоне: 1 100 = " + func6(1, 100));

//7 Время

let func7 = (h, m = 0, s = 0) => {
  let hh = isDigit(h) ? `0${h}` : h;
  let mm = isDigit(m) ? `0${m}` : m;
  let ss = isDigit(s) ? `0${s}` : s;
  return `${hh}:${mm}:${ss}`

}

console.log("7. Время: 1 2 3 = " + func7(1, 2, 3));
console.log("   Время: 5 22 = " + func7(5, 22));
console.log("   Время: 5 = " + func7(5));

//8 Время в секунды

let func8 = (h, m = 0, s = 0) => {
  return h * 3600 + m * 60 + s;
}

console.log("8. Время в секунды: 1 2 3 = " + func8(1, 2, 3));

//9 Секунды во время

let func9 = (sec) => {
  let h = Math.floor(sec / 3600);
  let m = Math.floor((sec - h * 3600) / 60);
  let s = sec - h * 3600 - m * 60;

  h = isDigit(h) ? `0${h}` : h;
  m = isDigit(m) ? `0${m}` : m;
  s = isDigit(s) ? `0${s}` : s;

  return `${h}:${m}:${s}`
}

console.log("9. Секунды во время: 134154 = " + func9(134154));

//10 Разница между датами - задание чушь, почему то написано даты перевести в секунды, оставлю просто разницу во времени
// Может конечно можно было перевести в UNIX, но тогда остальная часть задания теряется 

let func10 = (h1, m1, s1, h2, m2, s2) => {
  time1 = func8(h1, m1, s1);
  time2 = func8(h2, m2, s2);
  return func9(Math.abs(time1 - time2));
}

console.log("10. Разница между временем: 22:15:30, 17:05:15 = " + func10(22, 15, 30, 17, 5, 15));