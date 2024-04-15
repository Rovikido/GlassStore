export interface Glasses {
    id: string; // ObjectId
    price: number; // Цена
    brand: string; // Бренд
    model: string; // Модель
    frameColor: string; // Цвет оправы
    lensColor: string; // Цвет линз
    frameMaterial: string; // Материал оправы
    lensMaterial: string; // Материал линз
    isPrescription: boolean; // Наличие рецепта
    prescriptionType: string; // Тип рецепта
    frameWidth: number; // Ширина оправы
    bridgeWidth: number; // Ширина мостика
    templeLength: number; // Длина заушника
    gender: string; // Пол
    shape: string; // Форма
    style: string[]; // Стиль
    photos: string[]; // Фото
}
