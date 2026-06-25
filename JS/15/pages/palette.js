
class CookieManager {
  static set(name, value, hours = 3) {
    const expirationDate = new Date();
    expirationDate.setHours(expirationDate.getHours() + hours);
    
    const cookieString = `${name}=${encodeURIComponent(JSON.stringify(value))}; expires=${expirationDate.toUTCString()}; path=/`;
    document.cookie = cookieString;
  }

  static get(name) {
    const nameEQ = name + "=";
    const cookies = document.cookie.split(';');
    
    for (let cookie of cookies) {
      cookie = cookie.trim();
      if (cookie.indexOf(nameEQ) === 0) {
        try {
          return JSON.parse(decodeURIComponent(cookie.substring(nameEQ.length)));
        } catch (e) {
          return null;
        }
      }
    }
    return null;
  }

  static delete(name) {
    this.set(name, "", -1);
  }
}


class ColorValidator {
  static validateName(name) {
    if (!name || name.trim() === "") {
      return { valid: false, error: "Название обязательное поле" };
    }

    if (!/^[а-яА-ЯA-Za-z]+$/.test(name)) {
      return { valid: false, error: "Только буквенные символы" };
    }

    const colors = CookieManager.get("colors") || [];
    const nameExists = colors.some(color => color.name.toLowerCase() === name.toLowerCase());
    
    if (nameExists) {
      return { valid: false, error: "Такое название уже существует" };
    }

    return { valid: true, error: "" };
  }

  static validateRGB(code) {
    const parts = code.split(',').map(p => p.trim());
    
    if (parts.length !== 3) {
      return { valid: false, error: "RGB: 3 числа через запятую" };
    }

    return parts.every(part => {
      const num = parseInt(part);
      return !isNaN(num) && num >= 0 && num <= 255;
    }) 
      ? { valid: true, error: "" }
      : { valid: false, error: "RGB: каждое число от 0 до 255" };
  }

  static validateRGBA(code) {
    const parts = code.split(',').map(p => p.trim());
    
    if (parts.length !== 4) {
      return { valid: false, error: "RGBA: 4 числа через запятую" };
    }

    for (let i = 0; i < 3; i++) {
      const num = parseInt(parts[i]);
      if (isNaN(num) || num < 0 || num > 255) {
        return { valid: false, error: "RGBA: первые 3 числа от 0 до 255" };
      }
    }

    const alpha = parseFloat(parts[3]);
    return !isNaN(alpha) && alpha >= 0 && alpha <= 1
      ? { valid: true, error: "" }
      : { valid: false, error: "RGBA: последнее число от 0 до 1" };
  }

  static validateHEX(code) {
    const hexRegex = /^#[0-9A-Fa-f]{6}$/;
    
    return hexRegex.test(code)
      ? { valid: true, error: "" }
      : { valid: false, error: "HEX: # и 6 цифр или букв A-F" };
  }

  static validateCode(code, type) {
    if (!code || code.trim() === "") {
      return { valid: false, error: "Код цвета обязательное поле" };
    }

    switch (type) {
      case "RGB":
        return this.validateRGB(code);
      case "RGBA":
        return this.validateRGBA(code);
      case "HEX":
        return this.validateHEX(code);
      default:
        return { valid: false, error: "Неизвестный тип цвета" };
    }
  }
}

class ColorPalette {
  constructor() {
    this.colors = CookieManager.get("colors") || [];
    this.form = document.getElementById("colorForm");
    this.nameInput = document.getElementById("colorName");
    this.typeSelect = document.getElementById("colorType");
    this.codeInput = document.getElementById("colorCode");
    this.allColorsDiv = document.getElementById("allColors");

    this.form.addEventListener("submit", (e) => this.handleSubmit(e));
    this.render();
  }

  handleSubmit(e) {
    e.preventDefault();
    this.clearErrors();

    const name = this.nameInput.value;
    const type = this.typeSelect.value;
    const code = this.codeInput.value;

    const nameValidation = ColorValidator.validateName(name);
    const codeValidation = ColorValidator.validateCode(code, type);

    if (!nameValidation.valid) {
      document.getElementById("colorNameError").textContent = nameValidation.error;
      return;
    }

    if (!codeValidation.valid) {
      document.getElementById("colorCodeError").textContent = codeValidation.error;
      return;
    }

    const newColor = { name, type, code };
    this.colors.push(newColor);
    CookieManager.set("colors", this.colors, 3);

    this.form.reset();
    this.render();
  }

  clearErrors() {
    document.getElementById("colorNameError").textContent = "";
    document.getElementById("colorTypeError").textContent = "";
    document.getElementById("colorCodeError").textContent = "";
  }

  getColorStyle(color) {
    if (color.type === "RGB") {
      return `rgb(${color.code})`;
    } else if (color.type === "RGBA") {
      return `rgba(${color.code})`;
    } else if (color.type === "HEX") {
      return color.code;
    }
  }

  render() {
    this.allColorsDiv.innerHTML = "";

    if (this.colors.length === 0) {
      this.allColorsDiv.innerHTML = "<p>Цветов еще нет. Добавьте первый цвет!</p>";
      return;
    }

    const colorsContainer = document.createElement("div");
    colorsContainer.className = "colors-grid";

    this.colors.forEach((color, index) => {
      const colorBox = document.createElement("div");
      colorBox.className = "color-box";
      colorBox.style.backgroundColor = this.getColorStyle(color);

      const colorInfo = document.createElement("div");
      colorInfo.className = "color-info";

      const colorName = document.createElement("div");
      colorName.className = "color-name";
      colorName.textContent = color.name.toUpperCase();

      const colorType = document.createElement("div");
      colorType.className = "color-type";
      colorType.textContent = color.type;

      const colorCode = document.createElement("div");
      colorCode.className = "color-code";
      colorCode.textContent = color.code;

      const deleteBtn = document.createElement("button");
      deleteBtn.className = "delete-btn";
      deleteBtn.textContent = "✕";
      deleteBtn.addEventListener("click", () => this.deleteColor(index));

      colorInfo.appendChild(colorName);
      colorInfo.appendChild(colorType);
      colorInfo.appendChild(colorCode);
      colorInfo.appendChild(deleteBtn);

      colorBox.appendChild(colorInfo);
      colorsContainer.appendChild(colorBox);
    });

    this.allColorsDiv.appendChild(colorsContainer);
  }

  deleteColor(index) {
    this.colors.splice(index, 1);
    CookieManager.set("colors", this.colors, 3);
    this.render();
  }
}


document.addEventListener("DOMContentLoaded", () => {
  new ColorPalette();
});
