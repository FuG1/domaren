// Функция для плавного перехода к секции при клике на пункт меню
document.querySelectorAll('nav a').forEach(link => {
    link.addEventListener('click', function(event) {
        event.preventDefault();
        const target = this.getAttribute('href').substring(1);
        document.getElementById(target)?.scrollIntoView({ behavior: 'smooth' });
    });
});