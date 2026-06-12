const bookList = document.querySelector('.book-list');
let lastClickedItem;

bookList.addEventListener('click', (event) => {
  const clickedBook = event.target.closest('.book-item');

  if (!clickedBook) return;

  const previousSelected = bookList.querySelectorAll('.book-item.selected');

  if (previousSelected && !event.ctrlKey && !event.shiftKey) {
    previousSelected.forEach((book) => book.classList.remove('selected'));
  }

  if (event.ctrlKey) {
    clickedBook.classList.toggle('selected');
    return;
  }

  if (event.shiftKey && lastClickedItem) {
    const books = Array.from(bookList.querySelectorAll('.book-item'));
    const startIndex = books.indexOf(lastClickedItem);
    const endIndex = books.indexOf(clickedBook);
    const [from, to] = startIndex < endIndex ? [startIndex, endIndex] : [endIndex, startIndex];

    for (let i = from; i <= to; i++) {
      books[i].classList.add('selected');
    }
  }

  lastClickedItem = clickedBook;

  clickedBook.classList.add('selected');
});
