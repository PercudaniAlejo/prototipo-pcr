// tailwind.config.js
module.exports = {
    darkMode: 'false',
    content: [
        './Components/**/*.razor',
        './Pages/**/*.razor',
        './Shared/**/*.razor',
        './node_modules/flowbite/**/*.js'
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ],
}