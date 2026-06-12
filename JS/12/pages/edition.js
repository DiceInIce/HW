let textArea = document.querySelector('.text-area');

document.addEventListener('keydown', (event) => {

  if (event.code === 'KeyE' && event.ctrlKey) {
    event.preventDefault();
    textArea.setAttribute('contenteditable', true);
    textArea.focus();
  }

  if (event.code === 'KeyS' && event.ctrlKey) {
    event.preventDefault();
    textArea.setAttribute('contenteditable', false);
  }
});