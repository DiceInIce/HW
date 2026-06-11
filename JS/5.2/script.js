//1 Класс маркер

console.log('\n1. Класс маркер\n');

class Marker {
  constructor(color, ink) {
    this.color = color;
    this.ink = 100;
  }

  print(text) {
    let i = 0;
    let res = '';
    while(this.ink > 0 && i < text.length) {
      if (text[i] == ' ') {
        res += ' ';
        i++;
        continue;
      }
      res += text[i];
      this.ink -= 0.5;
      i++;
    }
    return res;
  }
}

let marker = new Marker('red', 100);
console.log(marker.print('Hello, world!'));
console.log(marker.ink);

class RefillMarker extends Marker {
  Refill(ink) {
    this.ink = 100;
  }
}

let refillMarker = new RefillMarker('red', 100);
console.log(refillMarker.print('Hello, world!'));
console.log(refillMarker.ink);
refillMarker.Refill();
console.log(refillMarker.ink);

//2 Расширенный класс даты

console.log('\n2. Расширенный класс даты\n');

class ExtendedDate extends Date {
  constructor(year, month, day) {
    super();
    this.year = year;
    this.month = month;
    this.day = day;
  }

  printDate() {
    return `Месяц : ${this.month}, День : ${this.day}`;
  }

  checkPastOrFuture() {
    let now = new Date();
    if (this.year < now.getFullYear() || this.month < now.getMonth() || this.day < now.getDate()) {
      return false;
    } else {
      return true;
    }
  }

  checkLeapYear() {
    if (this.year % 4 == 0 && this.year % 100 != 0 || this.year % 400 == 0) {
      return true;
    } else {
      return false;
    }
  }

  getNextDate() {
    return new Date(this.year, this.month, this.day + 1);
  }
}

let date = new ExtendedDate(2022, 12, 31);
console.log(date.printDate());
console.log(date.checkPastOrFuture());
console.log(date.checkLeapYear());
console.log(date.getNextDate());

//3 Класс Employee

console.log('\n3. Класс Employee\n');

class Employee {
  constructor(name, position, salary) {
    this.name = name;
    this.position = position;
    this.salary = salary;
  }
}

class EmpTable {
  constructor(employees) {
    this.employees = employees;
  }

  getHtml() {
    let table = '<table>';
    for (let employee of this.employees) {
      table += `<tr><td>${employee.name}</td><td>${employee.position}</td><td>${employee.salary}</td></tr>`;
    }
    return table + '</table>';
  }
}

let employees = [new Employee('Ivan', 'manager', 1000), new Employee('Petr', 'developer', 800)];
let empTable = new EmpTable(employees);
console.log(empTable.getHtml());
//document.write(empTable.getHtml());

// 4 Класс StyledEmpTable

console.log('\n4. Класс StyledEmpTable\n');

class StyledEmpTable extends EmpTable {
  getHtml() {
    let table = '<table>';
    for (let employee of this.employees) {
      table += `<tr style="background-color: ${employee.position == 'manager' ? 'red' : 'green'}"><td>${employee.name}</td><td>${employee.position}</td><td>${employee.salary}</td></tr>`;
    }
    return table + '</table>';
  }
}

let styledEmpTable = new StyledEmpTable(employees);
console.log(styledEmpTable.getHtml());
//document.write(styledEmpTable.getHtml()); 