let links = document.querySelectorAll('.links-list a');

links.forEach((link) => {
  if (link.href.includes('http')) {
    link.classList.add('is-http');
  }
});