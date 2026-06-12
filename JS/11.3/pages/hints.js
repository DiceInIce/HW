document.addEventListener('mouseover', (event) => {
  const button = event.target.closest('.button-with-hint');
  if (!button) return;

  const hint = document.createElement('div');
  hint.className = 'hint-text';
  hint.textContent = button.dataset.hint;
  
  document.body.appendChild(hint);

  const btnRect = button.getBoundingClientRect();
  
  let hintLeft = btnRect.left + window.scrollX + (btnRect.width - hint.offsetWidth) / 2;
  let hintTop = btnRect.top + window.scrollY - hint.offsetHeight - 12;
  if (btnRect.top - hint.offsetHeight - 12 < 0) {
    hintTop = btnRect.bottom + window.scrollY + 12;
    hint.classList.add('position-bottom');
  } else {
    hint.classList.add('position-top');
  }

  hint.style.left = hintLeft + 'px';
  hint.style.top = hintTop + 'px';
  button.addEventListener('mouseleave', () => {
    hint.remove();
  }, { once: true });
});