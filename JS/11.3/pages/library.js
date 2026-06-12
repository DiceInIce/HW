const bookList = document.querySelector('.book-list');

bookList.addEventListener('click', (event) => {
  const clickedBook = event.target.closest('.book-item');

  if (!clickedBook) return;

  const previousSelected = bookList.querySelector('.book-item.selected');

  if (previousSelected) {
    previousSelected.classList.remove('selected');
  }

  clickedBook.classList.add('selected');
});