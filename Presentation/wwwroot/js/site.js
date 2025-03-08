

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
