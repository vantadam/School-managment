const fs = require('fs');
const path = require('path');

const srcDir = path.resolve(__dirname, 'node_modules', 'chart.js', 'dist');
const destDir = path.resolve(__dirname, 'wwwroot', 'lib', 'chart.js');

if (!fs.existsSync(destDir)) {
    fs.mkdirSync(destDir, { recursive: true });
}

fs.copyFileSync(path.join(srcDir, 'chart.min.js'), path.join(destDir, 'chart.min.js'));
