var underlineColors = ['#56E39F', '#3772FF', '#DF2935'];

async function ChangeBackgroundColor(element) {
    element.style.setProperty('--underlinecolor', underlineColors[Math.floor(Math.random() * underlineColors.length)]);
};

async function UpdateView(element) {
    console.log(element);
    if (document.querySelector('a.link.active') !== null) {
        document.querySelector('a.link.active').classList.remove('active');
    }
}