//1 Класс круга
class Circle {

  constructor(radius) {
    this.radius = radius;
  }

  getRadius() {
    return this.radius;
  }

  setRadius(radius) {
    this.radius = radius;
  }

  getDiameter() {
    return this.radius * 2;
  }

  getArea() {
    return Math.round(Math.PI * Math.pow(this.radius, 2));
  }

  getCircumference() {
    return Math.round(2 * Math.PI * this.radius);
  }

}

let circle = new Circle(5);
console.log(`Радиус: ${circle.getRadius()}`);
console.log(`Диаметр: ${circle.getDiameter()}`);
console.log(`Площадь: ${circle.getArea()}`);
console.log(`Периметр окружности: ${circle.getCircumference()}`);

//2 Класс html элемента

class HtmlElement {
  constructor(tagName, isSelfClosing = false, textContent = "") {
    this.tagName = tagName;               
    this.isSelfClosing = isSelfClosing;   
    this.textContent = textContent;      
    this.attributes = [];                 
    this.styles = [];                     
    this.children = [];                  
  }

  setAttribute(name, value) {
    const existingAttr = this.attributes.find(attr => attr.name === name);
    if (existingAttr) {
      existingAttr.value = value;
    } else {
      this.attributes.push({ name, value });
    }
  }

  setStyle(name, value) {
    const existingStyle = this.styles.find(style => style.name === name);
    if (existingStyle) {
      existingStyle.value = value;
    } else {
      this.styles.push({ name, value });
    }
  }

  appendChild(element) {
    if (element instanceof HtmlElement) {
      this.children.push(element);
    }
  }

  prependChild(element) {
    if (element instanceof HtmlElement) {
      this.children.unshift(element);
    }
  }

  getHtml() {
    let stylesStr = this.styles
      .map(style => `${style.name}: ${style.value};`)
      .join(" ");

    let attrsStr = this.attributes
      .map(attr => `${attr.name}="${attr.value}"`)
      .join(" ");

    if (stylesStr) {
      attrsStr += ` style="${stylesStr}"`;
    }

    attrsStr = attrsStr ? " " + attrsStr : "";

    let html = `<${this.tagName}${attrsStr}>`;

    if (this.isSelfClosing) {
      return html;
    }

    html += this.textContent;

    for (let child of this.children) {
      html += child.getHtml();
    }

    html += `</${this.tagName}>`;

    return html;
  }
}

// 3 CSS клазсс

class CssClass {
  constructor(className) {
    this.className = className; 
    this.styles = [];
  }

  setStyle(name, value) {
    const existingStyle = this.styles.find(style => style.name === name);
    if (existingStyle) {
      existingStyle.value = value;
    } else {
      this.styles.push({ name, value });
    }
  }

  deleteStyle(name) {
    this.styles = this.styles.filter(style => style.name !== name);
  }
  getCss() {
    const stylesStr = this.styles
      .map(style => `  ${style.name}: ${style.value};`)
      .join("\n");

    const formattedName = this.className.startsWith('.') ? this.className : `.${this.className}`;

    return `${formattedName} {\n${stylesStr}\n}`;
  }
}

//4 класс блока

class HtmlBlock {
  constructor(rootElement) {
    if (rootElement instanceof HtmlElement) {
      this.rootElement = rootElement;
    }
    this.cssClasses = [];
  }

  addStyle(cssClass) {
    if (cssClass instanceof CssClass) {
      this.cssClasses.push(cssClass);
    }
  }

  getCode() {
    const stylesCode = this.cssClasses.map(c => c.getCss()).join("\n");
    const styleTag = `<style>\n${stylesCode}\n</style>\n`;

    const htmlCode = this.rootElement.getHtml();

    return styleTag + htmlCode;
  }
}

const wrapStyle = new CssClass("wrap");
wrapStyle.setStyle("display", "flex");

const blockStyle = new CssClass("block");
blockStyle.setStyle("width", "300px");
blockStyle.setStyle("margin", "10px");

const imgStyle = new CssClass("img");
imgStyle.setStyle("width", "100%");

const textStyle = new CssClass("text");
textStyle.setStyle("text-align", "justify");

const wrapper = new HtmlElement("div");
wrapper.setAttribute("id", "wrapper");
wrapper.setAttribute("class", "wrap");

function createCard() {
  const block = new HtmlElement("div");
  block.setAttribute("class", "block");

  const h3 = new HtmlElement("h3", false, "What is Lorem Ipsum?");
  block.appendChild(h3);

  const img = new HtmlElement("img", true);
  img.setAttribute("class", "img");
  img.setAttribute("src", "lipsum.jpg");
  img.setAttribute("alt", "Lorem Ipsum");
  block.appendChild(img);

  const textNode = `"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. "`;
  const p = new HtmlElement("p", false, textNode);
  p.setAttribute("class", "text");

  const link = new HtmlElement("a", false, "More...");
  link.setAttribute("href", "https://www.lipsum.com/");
  link.setAttribute("target", "_blank");
  
  p.appendChild(link);
  block.appendChild(p);

  return block;
}


wrapper.appendChild(createCard());
wrapper.appendChild(createCard());

const htmlBlock = new HtmlBlock(wrapper);

htmlBlock.addStyle(wrapStyle);
htmlBlock.addStyle(blockStyle);
htmlBlock.addStyle(imgStyle);
htmlBlock.addStyle(textStyle);

const finalCode = htmlBlock.getCode();

document.write(finalCode);

console.log(finalCode);