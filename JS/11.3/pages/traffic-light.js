let activeLight = document.querySelector('.active');
let unactiveLights = document.querySelectorAll('.unactive');
let btn = document.getElementById('next');

btn.addEventListener('click', () => {
  activeLight.classList.remove('active');
  activeLight.classList.add('unactive');

  if (activeLight.id == 'light-green') {
    let firstLight = document.getElementById('light-red');
    firstLight.classList.remove('unactive');
    firstLight.classList.add('active');
    activeLight = firstLight;
  } else {
    activeLight.nextElementSibling.classList.remove('unactive');
    activeLight.nextElementSibling.classList.add('active');
    activeLight = activeLight.nextElementSibling;
  }
})