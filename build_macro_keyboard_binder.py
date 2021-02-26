# Build Script for the Macro Keyboard Binder
# By Robert Sandoval
from zipfile import ZipFile
import os

build_path = ".\\Macro Key Binder\\bin\Release"
build_file = "Macro Key Binder.exe"
build_full_path = os.path.join(build_path, build_file)
zip_path = ".\\Build"
zip_name = "Macro Key Binder.zip"
arc_name = zip_name[0:-4]+"\\" + build_file

if os.path.exists(build_full_path):
    if not os.path.exists(zip_path):
        os.makedirs(zip_path)
    with ZipFile(os.path.join(zip_path, zip_name), 'w') as zip:
        zip.write(build_full_path, arc_name)
        print(f"Zipping {build_file} ...")
    print("Build zipped succesfully.")
else:
    print("ERROR: Build does not exist.")
