document.querySelectorAll('.tree-menu .has-children > .menu-item').forEach(item => {
  item.addEventListener('click', function(e) {
    this.parentElement.classList.toggle('collapsed');
  });
});