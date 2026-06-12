const input = document.getElementById('username');

input.addEventListener('keydown', (event) => {
  if (event.key >= '0' && event.key <= '9') {
    event.preventDefault();
  }
});