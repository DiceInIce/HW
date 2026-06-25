const canvas = document.getElementById('draw-canvas');
const ctx = canvas.getContext('2d');
const shapeButtons = document.querySelectorAll('.shape-btn');
const colorButtons = document.querySelectorAll('.color-btn');

let selectedShape = 'square';
let selectedColor = '#000000';
let isDrawing = false;
let startX = 0;
let startY = 0;
const defaultSize = 80;

function getCanvasCoordinates(event) {
  const rect = canvas.getBoundingClientRect();
  return {
    x: event.clientX - rect.left,
    y: event.clientY - rect.top,
  };
}

function updateSelection(buttons, selectedClass, valueKey, value) {
  buttons.forEach((btn) => {
    btn.classList.toggle('selected', btn.dataset[valueKey] === value);
  });
}

shapeButtons.forEach((button) => {
  button.addEventListener('click', () => {
    selectedShape = button.dataset.shape;
    updateSelection(shapeButtons, 'selected', 'shape', selectedShape);
  });
});

colorButtons.forEach((button) => {
  button.addEventListener('click', () => {
    selectedColor = button.dataset.color;
    updateSelection(colorButtons, 'selected', 'color', selectedColor);
  });
});

function drawShape(x, y, width, height, fillStyle, shape) {
  ctx.save();
  ctx.fillStyle = fillStyle;
  ctx.beginPath();

  switch (shape) {
    case 'circle': {
      const radius = Math.max(Math.abs(width), Math.abs(height)) / 2;
      const centerX = x + width / 2;
      const centerY = y + height / 2;
      ctx.arc(centerX, centerY, radius, 0, Math.PI * 2);
      break;
    }
    case 'diamond': {
      const centerX = x + width / 2;
      const centerY = y + height / 2;
      ctx.moveTo(centerX, y);
      ctx.lineTo(x + width, centerY);
      ctx.lineTo(centerX, y + height);
      ctx.lineTo(x, centerY);
      ctx.closePath();
      break;
    }
    case 'triangle': {
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x, y + height);
      ctx.closePath();
      break;
    }
    default:
      ctx.rect(x, y, width, height);
      break;
  }

  ctx.fill();
  ctx.restore();
}

function drawStandardShape(x, y) {
  const width = defaultSize;
  const height = defaultSize;
  const posX = x - width / 2;
  const posY = y - height / 2;
  drawShape(posX, posY, width, height, selectedColor, selectedShape);
}

canvas.addEventListener('mousedown', (event) => {
  const pos = getCanvasCoordinates(event);
  isDrawing = true;
  startX = pos.x;
  startY = pos.y;
});

canvas.addEventListener('mouseup', (event) => {
  if (!isDrawing) {
    return;
  }

  const pos = getCanvasCoordinates(event);
  isDrawing = false;

  const width = pos.x - startX;
  const height = pos.y - startY;

  if (Math.abs(width) < 10 && Math.abs(height) < 10) {
    drawStandardShape(pos.x, pos.y);
    return;
  }

  const rectX = width < 0 ? pos.x : startX;
  const rectY = height < 0 ? pos.y : startY;
  drawShape(rectX, rectY, Math.abs(width), Math.abs(height), selectedColor, selectedShape);
});
