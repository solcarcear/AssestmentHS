FROM node:latest as build

WORKDIR /usr/local/app

# Add the source code to app
COPY ./ /usr/local/app/
RUN npm install
RUN npm run build

# Use official nginx image as the base image
FROM nginx:latest

# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/local/app/dist/fe-app /usr/share/nginx/html
