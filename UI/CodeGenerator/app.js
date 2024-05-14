const { app, BrowserWindow } = require('electron/main')

const createWindow = () => {
  win = new BrowserWindow({show: false});
  win.maximize();
  win.show();

  win.loadFile('dist/code-generator/index.html')
}

app.whenReady().then(() => {
  createWindow()

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow()
    }
  })
})

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})