let btn = document.getElementById('open-modal');
let close = document.getElementById('close-modal');
  let modal = document.getElementById('modal');

btn.addEventListener('click', () => {
  modal.style.display = 'block';
});

close.addEventListener('click', () => {
  modal.style.display = 'none';
});
