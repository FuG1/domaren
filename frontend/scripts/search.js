// search.js

// Пример использования фильтров поиска
const form = document.querySelector('.filters form');

form.addEventListener('submit', function(event) {
    event.preventDefault();
    
    const minPrice = document.getElementById('price-min').value;
    const maxPrice = document.getElementById('price-max').value;

    // Здесь можно отправить данные фильтра на сервер или обновить результаты на клиенте
    console.log('Фильтр по цене:', minPrice, 'до', maxPrice);
    
    // Пример динамического обновления карточек
    const propertyCards = document.querySelectorAll('.property-card');
    propertyCards.forEach(card => {
        const priceText = card.querySelector('p:nth-child(3)').textContent;
        const price = parseInt(priceText.replace(/\D/g, '')); // Извлечение числового значения цены
        
        if (price < minPrice || price > maxPrice) {
            card.style.display = 'none';
        } else {
            card.style.display = 'block';
        }
    });
});