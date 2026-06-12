let field = document.getElementById('field');
let ball = document.getElementById('ball');

field.addEventListener('click', (event) => {
  ball.style.transition = 'left 0.7s, top 0.7s';

  let left = event.offsetX - ball.offsetWidth / 2;
  let top = event.offsetY - ball.offsetHeight / 2;

  let maxLeft = field.clientWidth - ball.offsetWidth;
  if (left < 0) left = 0;
  if (left > maxLeft) left = maxLeft;

  let maxTop = field.clientHeight - ball.offsetHeight;
  if (top < 0) top = 0;
  if (top > maxTop) top = maxTop;

  ball.style.left = left + 'px';
  ball.style.top = top + 'px';
});