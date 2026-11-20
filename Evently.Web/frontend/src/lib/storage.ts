export function readStored<T>(key: string, fallback: T): T {
  try {
    const value = window.localStorage.getItem(key);
    return value ? (JSON.parse(value) as T) : fallback;
  } catch {
    return fallback;
  }
}

export function writeStored<T>(key: string, value: T): void {
  try {
    window.localStorage.setItem(key, JSON.stringify(value));
  } catch {
    // Browser storage can be disabled or full; the in-memory experience still works.
  }
}

export async function compressImage(file: File): Promise<string> {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onerror = () => reject(new Error('The selected image could not be read.'));
    reader.onload = () => {
      const image = new Image();
      image.onerror = () => reject(new Error('The selected image is not valid.'));
      image.onload = () => {
        const maxWidth = 1200;
        const ratio = Math.min(1, maxWidth / image.width);
        const canvas = document.createElement('canvas');
        canvas.width = Math.round(image.width * ratio);
        canvas.height = Math.round(image.height * ratio);
        const context = canvas.getContext('2d');
        if (!context) return reject(new Error('Image preview is unavailable in this browser.'));
        context.drawImage(image, 0, 0, canvas.width, canvas.height);
        resolve(canvas.toDataURL('image/webp', 0.76));
      };
      image.src = String(reader.result);
    };
    reader.readAsDataURL(file);
  });
}
