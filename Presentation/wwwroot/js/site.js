

///// Change dark/light mode /////

const iconToggleTheme = document.getElementById("icon-dark-mode");

// Button dark/light click
const toggleTheme = () => {
    const currentTheme = document.documentElement.getAttribute("data-theme");
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    document.documentElement.setAttribute("data-theme", newTheme);
    localStorage.setItem("theme", newTheme);
    iconToggleTheme.classList.toggle("fa-moon");
};

// Apply stored theme on page load
document.addEventListener("DOMContentLoaded", () => {
    const savedTheme = localStorage.getItem("theme") || "light";
    document.documentElement.setAttribute("data-theme", savedTheme);
    if (savedTheme === "dark") iconToggleTheme.classList.remove("fa-moon");
});

///// End change dark/light mode /////


document.addEventListener("DOMContentLoaded", function () {
    const scrollContainer = document.getElementById("horizontalScrollContainer");
    const scrollLeftBtn = document.querySelector(".horizontal-scroll-left");
    const scrollRightBtn = document.querySelector(".horizontal-scroll-right");

    function updateScrollButtons() {
        if (scrollContainer.scrollLeft <= 0) {
            scrollLeftBtn.classList.add("hidden");
        } else {
            scrollLeftBtn.classList.remove("hidden");
        }

        if (scrollContainer.scrollLeft + scrollContainer.clientWidth >= scrollContainer.scrollWidth) {
            scrollRightBtn.classList.add("hidden");
        } else {
            scrollRightBtn.classList.remove("hidden");
        }
    }

    scrollLeftBtn.addEventListener("click", function () {
        scrollContainer.scrollBy({ left: -200, behavior: "smooth" });
    });

    scrollRightBtn.addEventListener("click", function () {
        scrollContainer.scrollBy({ left: 200, behavior: "smooth" });
    });

    scrollContainer.addEventListener("scroll", updateScrollButtons);
    updateScrollButtons();
});