// Пример удаления объекта из избранного
const savedProperties = document.querySelectorAll('.property-card');

savedProperties.forEach(card => {
    card.addEventListener('click', function() {
        if (confirm('Удалить этот объект из избранного?')) {
            card.remove(); // Удаление карточки из DOM
        }
    });
});