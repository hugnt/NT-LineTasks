import { z } from "zod";

const configSchema = z.object({
  API_ENDPOINT: z.string(),
});

const configProject = configSchema.safeParse({
  API_ENDPOINT: import.meta.env.VITE_API_ENDPOINT,
});
if (!configProject.success) {
  console.error(configProject.error.issues);
  throw new Error("Các giá trị khai báo trong file .env không hợp lệ");
}

const envConfig = configProject.data;
export default envConfig;
